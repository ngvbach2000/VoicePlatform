import 'package:flutter/material.dart';

import '../constants/constants.dart';
import '../models/voice_actor.dart';
import '../models/voice_demo.dart';
import '../models/voice_type.dart';
import '../widgets/audio_player_container.dart';
import '../widgets/badge.dart';
import '../widgets/detail_background.dart';
import '../widgets/layout.dart';

class DetailActorScreen extends StatefulWidget {
  const DetailActorScreen({Key? key}) : super(key: key);

  @override
  State<DetailActorScreen> createState() => _DetailActorScreenState();
}

class _DetailActorScreenState extends State<DetailActorScreen> {
  late VoiceActor voiceActor;

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;

    RouteSettings settings = ModalRoute.of(context)!.settings;
    voiceActor = settings.arguments as VoiceActor;

    return Scaffold(
      body: DetailBackground(
        child: Stack(
          alignment: Alignment.topLeft,
          children: <Widget>[
            Container(
              margin: EdgeInsets.fromLTRB(0, size.height * 0.1, 0, 0),
              child: Column(
                children: [
                  Center(
                    child: Column(
                      children: <Widget>[
                        // avatar
                        Container(
                          width: 90.0,
                          height: 90.0,
                          decoration: BoxDecoration(
                            color: const Color(0xff7c94b6),
                            image: DecorationImage(
                              image: NetworkImage(voiceActor.imageUrl),
                              fit: BoxFit.cover,
                            ),
                            borderRadius: const BorderRadius.all(
                              Radius.circular(50.0),
                            ),
                            border:
                                Border.all(color: appYellowColor, width: 4.0),
                          ),
                        ),
                        // name
                        const SizedBox(
                          height: 10.0,
                        ),
                        Text(
                          voiceActor.name,
                          style: const TextStyle(
                            fontWeight: FontWeight.bold,
                            fontSize: 20.0,
                          ),
                        ),
                        const SizedBox(
                          height: 5.0,
                        ),
                        // price - rating
                        Flex(
                          direction: Axis.horizontal,
                          mainAxisSize: MainAxisSize.max,
                          crossAxisAlignment: CrossAxisAlignment.center,
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: <Widget>[
                            Row(
                              mainAxisAlignment: MainAxisAlignment.center,
                              crossAxisAlignment: CrossAxisAlignment.center,
                              children: <Widget>[
                                Text(
                                  '${voiceActor.pricePerOneWord} VND/1 word',
                                  style: const TextStyle(
                                    fontWeight: FontWeight.w600,
                                    fontSize: 12.0,
                                  ),
                                ),
                                const SizedBox(
                                  width: 10.0,
                                ),
                                RichText(
                                  text: TextSpan(
                                    children: [
                                      TextSpan(
                                          text: '${voiceActor.rating} ',
                                          style: TextStyle(
                                            color:
                                                Colors.black.withOpacity(0.7),
                                            fontSize: 13.0,
                                          )),
                                      const WidgetSpan(
                                        child: Icon(
                                          Icons.star,
                                          size: 18.0,
                                          color: appYellowColor,
                                        ),
                                      ),
                                    ],
                                  ),
                                )
                              ],
                            ),
                          ],
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(
                    height: 17.0,
                  ),
                  Layout(
                    child: Column(
                      children: <Widget>[
                        // bio
                        Flex(
                          direction: Axis.horizontal,
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: <Widget>[
                            const Text(
                              'Lý lịch:',
                              style: TextStyle(
                                fontWeight: FontWeight.bold,
                                fontSize: 13.0,
                              ),
                            ),
                            const SizedBox(
                              width: 10.0,
                            ),
                            Expanded(
                              child: Text(
                                voiceActor.bio,
                                style: const TextStyle(
                                  fontSize: 12.0,
                                ),
                                maxLines: 5,
                                overflow: TextOverflow.ellipsis,
                              ),
                            )
                          ],
                        ),
                        // gender - region
                        const SizedBox(
                          height: 17.0,
                        ),
                        Flex(
                          direction: Axis.horizontal,
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: <Widget>[
                            Flex(
                              direction: Axis.vertical,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: <Widget>[
                                const Text(
                                  'Giới tính:',
                                  style: TextStyle(
                                    fontWeight: FontWeight.bold,
                                    fontSize: 13.0,
                                  ),
                                ),
                                const SizedBox(
                                  height: 4.0,
                                ),
                                Badge(
                                  text: voiceActor.gender,
                                  colorBadge: appDarkColor,
                                  colorText: Colors.white,
                                )
                              ],
                            ),
                            const SizedBox(
                              width: 10.0,
                            ),
                            Flex(
                              direction: Axis.vertical,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: <Widget>[
                                const Text(
                                  'Khu vực:',
                                  style: TextStyle(
                                    fontWeight: FontWeight.bold,
                                    fontSize: 13.0,
                                  ),
                                ),
                                const SizedBox(
                                  height: 4.0,
                                ),
                                Badge(
                                  text: voiceActor.region,
                                  colorBadge: appDarkColor,
                                  colorText: Colors.white,
                                )
                              ],
                            )
                          ],
                        ),
                        const SizedBox(
                          height: 15.0,
                        ),
                        // voice type
                        Align(
                          alignment: Alignment.topLeft,
                          child: Wrap(
                            spacing: 5.0,
                            runSpacing: 3.0,
                            children: <Widget>[
                              const Text(
                                'Loại giọng:',
                                style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  fontSize: 13.0,
                                ),
                              ),
                              for (VoiceType type in voiceActor.voiceTypes)
                                Badge(
                                  key: Key(type.id.toString()),
                                  text: type.name,
                                  colorText: appDarkColor,
                                  colorBadge: appYellowColor,
                                ),
                            ],
                          ),
                        ),
                        // mp3
                        SizedBox(
                          height: size.height * 0.03,
                        ),
                        for (VoiceDemo demo in voiceActor.voiceDemos)
                          AudioPlayerContainer(
                            path: demo.path,
                            key: Key(demo.id.toString()),
                          )
                      ],
                    ),
                  ),
                ],
              ),
            ),
            //button
            Positioned(
              bottom: 15.0,
              width: size.width,
              child: Layout(
                child: ElevatedButton(
                  onPressed: () {},
                  child: const Text(
                    'Mời tham gia',
                    style: TextStyle(
                      color: Colors.white,
                      fontSize: 14.0,
                      fontWeight: FontWeight.w600,
                    ),
                  ),
                  style: ButtonStyle(
                    backgroundColor:
                        MaterialStateProperty.all<Color>(appDarkColor),
                  ),
                ),
              ),
            ),
            Positioned(
              top: size.height * 0.05,
              left: size.width * 0.03,
              child: IconButton(
                padding: EdgeInsets.zero,
                onPressed: () {
                  Navigator.pop(context);
                },
                icon: Icon(
                  Icons.chevron_left,
                  size: size.width * 0.12,
                  color: const Color(0xFF848484),
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}
