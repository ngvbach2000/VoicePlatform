import 'package:voice_platform/models/voice_demo.dart';
import 'package:voice_platform/models/voice_type.dart';

class VoiceActor {
  String id;
  String imageUrl;
  String name;
  String bio;
  String gender;
  String region;
  List<VoiceType> voiceTypes;
  int pricePerOneWord;
  double rating;
  List<VoiceDemo> voiceDemos;

  VoiceActor(
      {required this.id,
      required this.imageUrl,
      required this.name,
      required this.bio,
      required this.gender,
      required this.region,
      required this.voiceTypes,
      required this.pricePerOneWord,
      required this.rating,
      required this.voiceDemos});

  factory VoiceActor.fromJson(Map<String, dynamic> json) {
    return VoiceActor(
      id: json['id'],
      imageUrl: json['imageUrl'],
      name: json['name'],
      bio: json['bio'],
      gender: json['gender'],
      region: json['region'],
      voiceTypes: parseVoiceTypes(json),
      pricePerOneWord: json['pricePerOneWord'],
      rating: json['rating'],
      voiceDemos: parseVoiceDemos(json),
    );
  }

  static List<VoiceType> parseVoiceTypes(voiceTypesJson) {
    var list = voiceTypesJson['voiceTypes'] as List;
    List<VoiceType> voiceTypesList =
        list.map((data) => VoiceType.fromJson(data)).toList();
    return voiceTypesList;
  }

  static List<VoiceDemo> parseVoiceDemos(voiceDemosJson) {
    var list = voiceDemosJson['voiceDemos'] as List;
    List<VoiceDemo> voiceDemosList =
        list.map((data) => VoiceDemo.fromJson(data)).toList();
    return voiceDemosList;
  }
}
