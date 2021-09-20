import 'package:flutter/material.dart';
import 'package:simple_shadow/simple_shadow.dart';
import 'package:voice_platform/models/voice_actor.dart';
import '../constants/constants.dart';

class VoiceActorModal extends StatelessWidget {
  final VoiceActor voiceActor;

  const VoiceActorModal({
    Key? key,
    required this.voiceActor,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.pushNamed(context, '/detail', arguments: voiceActor);
      },
      child: Container(
        margin: const EdgeInsets.symmetric(
          vertical: 5.0,
        ),
        padding: const EdgeInsets.symmetric(
          horizontal: 12.0,
          vertical: 7.0,
        ),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(25.0),
          color: Colors.white,
          boxShadow: [
            BoxShadow(
              color: Colors.grey.withOpacity(0.5),
              spreadRadius: 2.0,
              blurRadius: 3.0,
              offset: const Offset(2.0, 4.0),
            )
          ],
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.start,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            Stack(
              children: <Widget>[
                Container(
                  width: 90,
                  decoration: const BoxDecoration(
                    color: Colors.white,
                  ),
                  alignment: Alignment.center,
                  child: SimpleShadow(
                    opacity: 0.6,
                    color: Colors.grey,
                    offset: const Offset(0, 2.0),
                    sigma: 2.0,
                    child: ClipRRect(
                      borderRadius: BorderRadius.circular(25.0),
                      child: Image.network(
                        voiceActor.imageUrl,
                        fit: BoxFit.fill,
                      ),
                    ),
                  ),
                ),
                const Positioned(
                  right: 5.0,
                  bottom: 10,
                  child: Icon(
                    Icons.slow_motion_video_rounded,
                    color: appYellowColor,
                  ),
                )
              ],
            ),
            Expanded(
              child: DefaultTextStyle.merge(
                style: const TextStyle(
                  fontSize: 11.0,
                ),
                child: Container(
                  margin: const EdgeInsets.fromLTRB(17.0, 0, 0, 0),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    mainAxisSize: MainAxisSize.min,
                    children: <Widget>[
                      Text(
                        voiceActor.name,
                        style: const TextStyle(fontWeight: FontWeight.bold),
                      ),
                      const SizedBox(
                        height: 2.0,
                      ),
                      Text(
                        voiceActor.bio,
                        style: const TextStyle(height: 1.3, letterSpacing: -0.165),
                        overflow: TextOverflow.ellipsis,
                        maxLines: 2,
                      ),
                      const SizedBox(
                        height: 2.0,
                      ),
                      Text(
                        'Giới tính: ${voiceActor.gender}',
                        overflow: TextOverflow.ellipsis,
                      ),
                      const SizedBox(
                        height: 2.0,
                      ),
                      Text(
                        'Loại giọng: ${voiceActor.voiceTypes.first.name}',
                        overflow: TextOverflow.ellipsis,
                      ),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.end,
                        crossAxisAlignment: CrossAxisAlignment.end,
                        children: <Widget>[
                          Text(
                            '${voiceActor.pricePerOneWord} đ/1 chữ',
                            style: const TextStyle(
                              fontWeight: FontWeight.bold,
                              fontSize: 11.0,
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
                                      color: Colors.black.withOpacity(0.7),
                                      fontSize: 11.0,
                                    )),
                                const WidgetSpan(
                                  child: Icon(
                                    Icons.star,
                                    size: 17.0,
                                    color: appYellowColor,
                                  ),
                                ),
                              ],
                            ),
                          )
                        ],
                      )
                    ],
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
